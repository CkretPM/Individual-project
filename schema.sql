-- ============================================================
-- MULTIPLAYER TILE GAME  –  PostgreSQL Schema
-- Run this once against your gamedb database:
--   psql -h localhost -U gameuser -d gamedb -f schema.sql
-- ============================================================

-- ---------- players ----------
CREATE TABLE IF NOT EXISTS players (
    player_id   UUID        PRIMARY KEY,
    player_name VARCHAR(64) NOT NULL,
    color       VARCHAR(32) NOT NULL DEFAULT 'White',
    is_ready    BOOLEAN     NOT NULL DEFAULT FALSE,
    joined_at   TIMESTAMPTZ NOT NULL DEFAULT NOW()
);

-- ---------- game sessions ----------
CREATE TABLE IF NOT EXISTS game_sessions (
    session_id   SERIAL      PRIMARY KEY,
    started_at   TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    is_active    BOOLEAN     NOT NULL DEFAULT TRUE
);

-- ---------- turns ----------
CREATE TABLE IF NOT EXISTS turns (
    turn_id          SERIAL      PRIMARY KEY,
    session_id       INT         NOT NULL REFERENCES game_sessions(session_id),
    player_id        UUID        NOT NULL REFERENCES players(player_id),
    player_index     INT         NOT NULL DEFAULT 0,  -- 0-based join order (0 to 3)
    tile_id          INT         NOT NULL,
    num_of_rotation  INT         NOT NULL,
    tile_index       INT         NOT NULL,            -- placement index / palace ID
    turn_number      INT         NOT NULL,            -- 1-based sequential turn in the session
    played_at        TIMESTAMPTZ NOT NULL DEFAULT NOW()
);

-- ============================================================
--  TRIGGERS
-- ============================================================

-- ---------- lobby_refresh: any player row changes → refresh lobby ----------
CREATE OR REPLACE FUNCTION notify_lobby_refresh()
RETURNS TRIGGER LANGUAGE plpgsql AS $$
BEGIN
    PERFORM pg_notify('lobby_refresh', '');
    RETURN NEW;
END;
$$;

DROP TRIGGER IF EXISTS trg_notify_lobby_refresh ON players;
CREATE TRIGGER trg_notify_lobby_refresh
    AFTER UPDATE OF is_ready ON players
    FOR EACH ROW
    EXECUTE FUNCTION notify_lobby_refresh();

-- ---------- game_start: all players ready → create session + notify ----------
CREATE OR REPLACE FUNCTION notify_game_start()
RETURNS TRIGGER LANGUAGE plpgsql AS $$
DECLARE
    total_players  INT;
    ready_players  INT;
BEGIN
    SELECT COUNT(*) INTO total_players FROM players;
    SELECT COUNT(*) INTO ready_players FROM players WHERE is_ready = TRUE;

    IF total_players >= 2 AND total_players = ready_players THEN
        INSERT INTO game_sessions DEFAULT VALUES;
        PERFORM pg_notify('game_start', 'all_ready');
    END IF;

    RETURN NEW;
END;
$$;

DROP TRIGGER IF EXISTS trg_notify_game_start ON players;
CREATE TRIGGER trg_notify_game_start
    AFTER UPDATE OF is_ready ON players
    FOR EACH ROW
    EXECUTE FUNCTION notify_game_start();

-- ---------- new_turn: tile placed → notify all players ----------
-- Payload: "tileId:numOfRotation:tileIndex:playerIndex"
CREATE OR REPLACE FUNCTION notify_new_turn()
RETURNS TRIGGER LANGUAGE plpgsql AS $$
BEGIN
    PERFORM pg_notify(
        'new_turn',
        NEW.tile_id::TEXT         || ':' ||
        NEW.num_of_rotation::TEXT || ':' ||
        NEW.tile_index::TEXT      || ':' ||
        NEW.player_index::TEXT
    );
    RETURN NEW;
END;
$$;

DROP TRIGGER IF EXISTS trg_notify_new_turn ON turns;
CREATE TRIGGER trg_notify_new_turn
    AFTER INSERT ON turns
    FOR EACH ROW
    EXECUTE FUNCTION notify_new_turn();
