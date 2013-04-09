using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using spnmario;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CollisionWeb testme = new CollisionWeb(new Rectangle(40, 40, 70, 70));
            Vector2 vector = new Vector2(7,7);
            CollisionWeb.vectorUpdate(8, 8, vector);
            vector.X = 9;
            Assert.IsTrue(vector.X == (float)9);
        }
    }
}
