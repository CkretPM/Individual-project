using Microsoft.VisualStudio.TestTools.UnitTesting;
using Indigo;

namespace Indigo
{
    [TestClass]
    public class FormConstructionTests
    {
        // Test 1: MultiplayerManager is created with a connection string
        [TestMethod]
        public void MultiplayerManager_CreatedWithConnectionString_IsNotNull()
        {
            const string connectionString =
                "Host=localhost;Port=5432;Database=gamedb;Username=gameuser;Password=gamepass;";

            var manager = new MultiplayerManager(connectionString);

            Assert.IsNotNull(manager,
                "MultiplayerManager should not be null after construction.");
        }

        // Test 2: Tile transfer constructor (no image loading) sets fields
        //         Uses Tile(int id, int numOfRotation, int index)
        [TestMethod]
        public void Tile_TransferConstructor_StoresAllFields()
        {
            const int id = 3;
            const int numOfRotation = 2;
            const int index = 11;

            var tile = new Tile(id, numOfRotation, index);

            Assert.AreEqual(id, tile.id, "id mismatch.");
            Assert.AreEqual(numOfRotation, tile.numOfRotation, "numOfRotation mismatch.");
            Assert.AreEqual(index, tile.index, "index mismatch.");
        }

        // Test 3: PlayerInfo record stores all four fields correctly
        [TestMethod]
        public void PlayerInfo_Construction_StoresAllFields()
        {
            var id = Guid.NewGuid();
            const string name = "Player_1a2b";
            const string color = "Red";
            const bool isReady = true;

            var info = new PlayerInfo(id, name, color, isReady);

            Assert.AreEqual(id, info.PlayerId, "PlayerId mismatch.");
            Assert.AreEqual(name, info.Name, "Name mismatch.");
            Assert.AreEqual(color, info.Color, "Color mismatch.");
            Assert.AreEqual(isReady, info.IsReady, "IsReady mismatch.");
        }
    }
}