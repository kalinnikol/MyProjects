using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace ImageGallery.ViewModels
{
    public class DataPersister
    {
        public static IEnumerable<AlbumViewModel> GetAll(string galleryPath)
        {
            var albumsDocumentRoot = XDocument.Load(galleryPath).Root;

            var albums =
                           from albumsQuery in albumsDocumentRoot.Elements("album")
                           select new AlbumViewModel()
                           {
                               Name = albumsQuery.Element("name").Value,
                               ImagesEnumerable =
                               from imagesQuery in albumsQuery.Element("images").Elements("image")
                                        select new ImageViewModel()
                                        {
                                            Title = imagesQuery.Element("title").Value,
                                            Source = //Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                                            imagesQuery.Element("source").Value
                                        }
                           };

            return albums;
        }
    }
}
