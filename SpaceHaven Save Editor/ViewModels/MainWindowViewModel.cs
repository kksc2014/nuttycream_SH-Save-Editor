﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.Input;
using SpaceHaven_Save_Editor.FileHandling;
using SpaceHaven_Save_Editor.ViewModels.Base;
using Character = SpaceHaven_Save_Editor.CharacterData.Character;

namespace SpaceHaven_Save_Editor.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly ReadFile _readFile;
        private readonly WriteFile _writeFile;

        private CharacterViewModel _characterViewModel;
        private StorageViewModel _storageViewModel;
        
        private List<Character> _characters = new();

        public MainWindowViewModel()
        {
            _readFile = new ReadFile();
            _writeFile = new WriteFile();

            OpenFile = new AsyncRelayCommand(Open);
            CreateBackUp = new AsyncRelayCommand(BackUp);
            SaveFile = new AsyncRelayCommand(Save);
            ClearLog = new RelayCommand(ClearLogText);

            _readFile.ProgressList += UpdateProgress;
            _writeFile.ProgressList += UpdateProgress;
            
            _characterViewModel = new CharacterViewModel();
            _storageViewModel = new StorageViewModel();
        }

        public BaseViewModel CharacterContent => _characterViewModel;
        public BaseViewModel StorageViewModel => _storageViewModel;
        
        public ICommand OpenFile { get; }
        public ICommand CreateBackUp { get; }
        public ICommand SaveFile { get; }
        public ICommand ClearLog { get; }

        public string FilePath { get; private set; }
        public string BackUpFilePath { get; private set; }
        public string PlayerCredits { get; set; }
        public string ReadLogText { get; private set; }
        
        private void UpdateProgress(string obj) => ReadLogText += obj + "\n";

        private void ClearLogText() => ReadLogText = "Log Cleared\n";
        
        private async Task Save()
        {
            await Task.Run(() => _writeFile.Write(FilePath, _characterViewModel.Characters, _storageViewModel.Ship, PlayerCredits));
        }

        private async Task Open()
        {
            _characters = await Task.Run(() => _readFile.LoadSave());
            
            FilePath = _readFile.FilePath;
            PlayerCredits = _readFile.PlayerCredits;
            
            _characterViewModel.Characters = _characters;
            _storageViewModel.Ship = _readFile.Ship;
        }

        private async Task BackUp() => BackUpFilePath = await Task.Run(() => _readFile.CreateBackUp());

        
    }
}