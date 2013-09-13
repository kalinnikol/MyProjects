using ImageGallery.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

namespace ImageGallery.ViewModels
{
    public class AlbumViewModel:INotifyPropertyChanged
    {
        private ImageViewModel currentImage;

        private ICommand previous;

        private ICommand next;

        private ObservableCollection<ImageViewModel> images;

        public string Name { get; set; }

        public ImageViewModel CurrentImage
        {
            get
            {
                var view = CollectionViewSource.GetDefaultView(this.Images);
                this.currentImage = view.CurrentItem as ImageViewModel;
                return this.currentImage;
            }
            set
            {
                this.currentImage = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("CurrentImage"));
                }
            }
        }

        public IEnumerable<ImageViewModel> ImagesEnumerable { get; set; }

        public ObservableCollection<ImageViewModel> Images
        {
            get
            {
                if (this.images == null)
                {
                    this.images = new ObservableCollection<ImageViewModel>();
                    foreach (var image in ImagesEnumerable)
                    {
                        this.images.Add(image);
                    }

                }
                return this.images;
            }
        }

        public AlbumViewModel()
        {
        }

        public ICommand Previous
        {
            get
            {
                if (previous == null)
                {
                    this.previous = new RelayCommand(this.HandlePreviousCommand);
                }
                return previous;
            }
        }

        public ICommand Next
        {
            get
            {
                if (this.next == null)
                {
                    this.next = new RelayCommand(this.HandleNextCommand);
                }
                return this.next;
            }
        }

        private void HandleNextCommand(object obj)
        {
            var view = CollectionViewSource.GetDefaultView(this.Images);
            view.MoveCurrentToNext();
            if (view.IsCurrentAfterLast)
            {
                view.MoveCurrentToFirst();
            }
            this.CurrentImage = view.CurrentItem as ImageViewModel;
        }

        private void HandlePreviousCommand(object obj)
        {
            var view = CollectionViewSource.GetDefaultView(this.Images);
            view.MoveCurrentToPrevious();
            if (view.IsCurrentBeforeFirst)
            {
                view.MoveCurrentToLast();
            }
            this.CurrentImage = view.CurrentItem as ImageViewModel;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
