﻿//using System;
//using System.Text;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//using BGGwrapper.Client;
//using BGGwrapper.Settings;

//namespace BGGwrapper_Test
//{
//    [TestClass]
//    public class SearchXML
//    {
//        [TestMethod]
//        public void search_WithDefaultSettings_ReturnsAGameWithRightNames()
//        {
//            // Arrange
//            IBGGClient client = new BGGXMLClient();
            
//            // Act
//            var result = client.searchBoardGame("7 Wonders");

//            // Assert
//            Assert.IsTrue(result.Any(x => x.name == "7 Wonders"));
//        }

//        [TestMethod]
//        public void search_WithDefaultSettings_ReturnsManyGamesWithRightNames()
//        {
//            // Arrange
//            IBGGClient client = new BGGXMLClient();
            
//            // Act
//            var result = client.searchBoardGame("7 Wonders");

//            // Assert
//            Assert.IsTrue(1 < result.Count(x => x.name.Contains("7 Wonders")));
//        }

//        [TestMethod]
//        public void search_WithExact_ReturnsCorrectGame()
//        {
//            // Arrange
//            IBGGClient client = new BGGXMLClient();
            
//            // Act
//            var result = client.searchBoardGame(SearchSettings.exact, "7 Wonders");

//            // Assert
//            Assert.IsTrue(result.Any(x => x.name == "7 Wonders"));
//        }

//        [TestMethod]
//        public void search_WithExact_ReturnsOneGame()
//        {
//            // Arrange
//            IBGGClient client = new BGGXMLClient();
            
//            // Act
//            var result = client.searchBoardGame(SearchSettings.exact, "7 Wonders");

//            // Assert
//            Assert.AreEqual(1, result.Count);
//        }
//    }
//}
