﻿using System.Collections.ObjectModel;
using System.Xml;
using ReactiveUI;

namespace SpaceHaven_Save_Editor.Data
{
    public class Ship : ReactiveObject
    {
        private string _shipFaction;
        private string _shipState;
        private int _shipSizeX;
        private int _shipSizeY;

        public Ship()
        {
            ShipName = "";
            _shipFaction = "";
            _shipState = "";
            Characters = new ObservableCollection<Character>();
            ToolFacilities = new ObservableCollection<ToolFacility>();
            StorageFacilities = new ObservableCollection<StorageFacility>();
        }

        public string ShipName { get; set; }

        public XmlNode? ShipNode { get; set; }

        public string ShipFaction
        {
            get => _shipFaction;
            set => this.RaiseAndSetIfChanged(ref _shipFaction, value);
        }

        public string ShipState
        {
            get => _shipState;
            set => this.RaiseAndSetIfChanged(ref _shipState, value);
        }
        
        public int ShipSizeX
        {
            get => _shipSizeX;
            set => this.RaiseAndSetIfChanged(ref _shipSizeX, value);
        }
        
        public int ShipSizeY
        {
            get => _shipSizeY;
            set => this.RaiseAndSetIfChanged(ref _shipSizeY, value);
        }

        public ObservableCollection<Character> Characters { get; set; }
        public ObservableCollection<ToolFacility> ToolFacilities { get; set; }
        public ObservableCollection<StorageFacility> StorageFacilities { get; set; }

        public override string ToString()
        {
            return ShipName;
        }
    }
}