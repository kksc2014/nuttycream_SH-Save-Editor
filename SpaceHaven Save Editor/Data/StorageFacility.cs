﻿using System.Collections.ObjectModel;
using ReactiveUI;

namespace SpaceHaven_Save_Editor.Data
{
    public class StorageFacility : ReactiveObject
    {
        private ObservableCollection<DataProp> _cargo;

        public StorageFacility()
        {
            _cargo = new ObservableCollection<DataProp>();
        }

        public ObservableCollection<DataProp> Cargo
        {
            get => _cargo;
            set => this.RaiseAndSetIfChanged(ref _cargo, value);
        }

        public string StorageFacilityName =>
            Cargo.Count switch
            {
                > 1 => "Storage with... [" + Cargo[0].Name + ", " + Cargo[1].Name + "]",
                1 => "Storage with... [" + Cargo[0].Name + "]",
                _ => "Empty Storage Facility"
            };
    }
}