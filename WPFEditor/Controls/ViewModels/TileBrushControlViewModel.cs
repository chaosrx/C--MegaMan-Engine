﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using MegaMan.Editor.Bll;
using MegaMan.Editor.Bll.Tools;
using MegaMan.Editor.Mediator;
using MegaMan.Editor.Tools;

namespace MegaMan.Editor.Controls.ViewModels
{
    public class TileBrushControlViewModel : INotifyPropertyChanged, IToolProvider
    {
        private TilesetDocument _tileset;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddTileBrushCommand { get; private set; }

        public IEnumerable<MultiTileBrush> Brushes
        {
            get
            {
                if (_tileset == null)
                    return Enumerable.Empty<MultiTileBrush>();
                else
                    return _tileset.Brushes;
            }
        }

        private void OnPropertyChanged(string property)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(property));
            }
        }

        public TileBrushControlViewModel()
        {
            ViewModelMediator.Current.GetEvent<StageChangedEventArgs>().Subscribe(StageChanged);

            AddTileBrushCommand = new RelayCommand(AddTileBrush, o => _tileset != null);
        }

        private void AddTileBrush(object obj)
        {

        }

        private void StageChanged(object sender, StageChangedEventArgs e)
        {
            if (e.Stage != null)
                SetTileset(e.Stage.Tileset);
            else
                SetTileset(null);
        }

        private void SetTileset(TilesetDocument tileset)
        {
            _tileset = tileset;

            OnPropertyChanged("Brushes");
        }

        internal void SelectBrush(MultiTileBrush multiTileBrush)
        {
            Tool = new TileBrushToolBehavior(multiTileBrush);
            ToolCursor = new MultiTileCursor(multiTileBrush);

            if (ToolChanged != null)
            {
                ToolChanged(this, new ToolChangedEventArgs(Tool));
            }
        }

        public IToolBehavior Tool
        {
            get;
            private set;
        }

        public IToolCursor ToolCursor
        {
            get;
            private set;
        }

        public event System.EventHandler<ToolChangedEventArgs> ToolChanged;
    }
}