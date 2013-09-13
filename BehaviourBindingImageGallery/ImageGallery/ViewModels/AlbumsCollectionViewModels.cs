using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using ImageGallery.Commands;
using System.Windows.Data;
using System.Collections.ObjectModel;

namespace ImageGallery.ViewModels
{
    public class AlbumsCollectionViewModels
    {

        public ObservableCollection<AlbumViewModel> Albums { get; set; }

        public AlbumsCollectionViewModels()
        {
            var albums = DataPersister.GetAll("..\\..\\albums.xml");
            if (this.Albums==null)
            {
                this.Albums = new ObservableCollection<AlbumViewModel>();
                
                foreach (var album in albums)
                {
                    this.Albums.Add(album);
                }
            }
        }
    }
}
