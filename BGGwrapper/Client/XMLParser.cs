using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using BGGwrapper.Objects;

namespace BGGwrapper.Client
{
    public class XMLParser : IXMLParser
    {
        public List<BoardGame> parseBoardGameXML(XDocument input)
        {
            var boardgames = (from data in input.Descendants("boardgame")
                             select new BoardGame
                             {
                                 age = (int?) data.Element("age") ?? 0,
                                 description = (string) data.Element("description") ?? "",
                                 imageThumnailURL = (string) data.Element("thumbnail") ?? "",
                                 imageURL = (string) data.Element("image") ?? "",
                                 maxPlayers = (int?) data.Element("maxplayers") ?? 0,
                                 minPlayers = (int?) data.Element("minplayers") ?? 0,
                                 ObjectID = (int?) data.Attribute("objectid") ?? 0,
                                 yearPublished = (int?) data.Element("yearpublished") ?? 0,
                                 playingTime = (int?) data.Element("playingtime") ?? 0,

                                 BoardGameCategories = (from cat in data.Elements("boardgamecategory")
                                               select new BoardGameCategories
                                               {
                                                   value = (string) cat ?? "",
                                                   BGCobjectID = (int?) cat.Attribute("objectid") ?? 0
                                               }).ToList(),

                                 BoardGameDesigner = (from des in data.Elements("boardgamedesigner")
                                                      select new BoardGameDesigner
                                                      {
                                                          value = (string)des ?? "",
                                                          BGDobjectID = (int?)des.Attribute("objectid") ?? 0
                                                      }).ToList(),

                                 BoardGameExpansions = (from exp in data.Elements("boardgameexpansion")
                                                        select new BoardGameExpansions
                                                        {
                                                            value = (string)exp ?? "",
                                                            BGEobjectID = (int?)exp.Attribute("objectid") ?? 0
                                                        }).ToList(),

                                 BoardGameHonors = (from hon in data.Elements("boardgamehonor")
                                                    select new BoardGameHonors
                                                    {
                                                        value = (string)hon ?? "",
                                                        BGHobjectID = (int?)hon.Attribute("objectid") ?? 0
                                                    }).ToList(),

                                 BoardGameMechanics = (from mec in data.Elements("boardgamemechanic")
                                                       select new BoardGameMechanics
                                                       {
                                                           value = (string)mec ?? "",
                                                           BGMobjectID = (int?)mec.Attribute("objectid") ?? 0
                                                       }).ToList(),

                                 BoardGameName = (from name in data.Elements("name")
                                                  select new BoardGameName
                                                  {
                                                      name = (string)name ?? "",
                                                      sortIndex = (int?)name.Attribute("sortindex") ?? 0,
                                                      isPrimary = (bool?)name.Attribute("primary") ?? false
                                                  }).ToList(),



                                 BoardGamePublisher = (from pub in data.Elements("boardgamepublisher")
                                                       select new BoardGamePublisher
                                                       {
                                                           value = (string)pub ?? "",
                                                           BGPobjectID = (int?)pub.Attribute("objectid") ?? 0
                                                       }).ToList(),

                                 BoardGameSubdomains = (from sub in data.Elements("boardgamesubdomain")
                                                        select new BoardGameSubdomains
                                                        {
                                                            value = (string)sub ?? "",
                                                            BGSobjectID = (int?)sub.Attribute("objectid") ?? 0
                                                        }).ToList(),

                                 BoardGameVersions = (from ver in data.Elements("boardgameversion")
                                                      select new BoardGameVersions
                                                      {
                                                          value = (string)ver ?? "",
                                                          BGVobjectID = (int?)ver.Attribute("objectid") ?? 0
                                                      }).ToList(),


                             });

            return boardgames.ToList();
        }

        

        public List<CollectionItem> parseCollectionXML(XDocument input)
        {
            var collection = from coll in input.Descendants("item")
                             select new CollectionItem
                             {
                                 ObjectID = (int?) coll.Attribute("objectid") ?? 0
                             };

            return collection.ToList();
        }

       

       
    }
}
