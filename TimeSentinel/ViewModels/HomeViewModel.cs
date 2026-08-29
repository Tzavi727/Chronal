using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSentinel.Models;

namespace TimeSentinel.ViewModels;

public partial class HomeViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<TrackedProcess> _processList;

    public HomeViewModel(ObservableCollection<TrackedProcess> sharedList)
    {
        ProcessList = sharedList;
    }
}


