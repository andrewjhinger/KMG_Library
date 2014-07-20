using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BGGwrapper.Client;
using BGGwrapper.Objects;
using BGGwrapper.Settings;

namespace BGGwrapper_Test
{
    /// <summary>
    /// Summary description for CollectionXML
    /// </summary>
    [TestClass]
    public class CollectionXML
    {
        [TestMethod]
        public void userCollections_NoSettings_CollectionFetchedByDefault()
        {
            // Arrange
            IBGGClient client = new BGGXMLClient();

            // Act
            var result = client.getUserCollection("rokusho");

            // Assert
            Assert.IsTrue(result.Count > 0);
        }
    }
}
