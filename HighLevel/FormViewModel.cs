namespace HighLevel;


using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows.Input;
using Microsoft.Maui.Storage;

public class FormViewModel : INotifyPropertyChanged
{
    private string id;
    public string Id
    {
        get => id;
        set
        {
            id = value;
            OnPropertyChanged();
        }
    }

    private string latitude;
    public string Latitude
    {
        get => latitude;
        set
        {
            latitude = value;
            OnPropertyChanged();
        }
    }

    private string longitude;
    public string Longitude
    {
        get => longitude;
        set
        {
            longitude = value;
            OnPropertyChanged();
        }
    }

    private string name;
    public string Name
    {
        get => name;
        set
        {
            name = value;
            OnPropertyChanged();
        }
    }

    private string level;
    public string Level
    {
        get => level;
        set
        {
            level = value;
            OnPropertyChanged();
        }
    }

    public ICommand SubmitCommand { get; }

    public FormViewModel()
    {
        SubmitCommand = new Command(OnSubmit);
    }

    private async void OnSubmit()
    {
        var formData = new
        {
            Id = this.Id,
            Latitude = this.Latitude,
            Longitude = this.Longitude,
            Name = this.Name,
            Level = this.Level
        };

        string json = JsonSerializer.Serialize(formData);
        string filePath = Path.Combine(FileSystem.AppDataDirectory, "formData.json");

        await File.WriteAllTextAsync(filePath, json);

        // Optional: Display an alert to confirm submission
        await Application.Current.MainPage.DisplayAlert("Success", "Data saved to JSON file", "OK");
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}


// namespace HighLevel;

// using System.ComponentModel;
// using System.Runtime.CompilerServices;
// using System.Text.Json;
// using System.Windows.Input;

// public class FormViewModel : INotifyPropertyChanged
// {
//     public ICommand SubmitCommand { get; }
//     private string id;
//     public string Id
//     {
//         get => id;
//         set { id = value; OnPropertyChanged(nameof(Id)); }
//     }

//     private string latitude;
//     public string Latitude
//     {
//         get => latitude;
//         set { latitude = value; OnPropertyChanged(nameof(Latitude)); }
//     }

//     private string longitude;
//     public string Longitude
//     {
//         get => longitude;
//         set { longitude = value; OnPropertyChanged(nameof(Longitude)); }
//     }

//     private string name;
//     public string Name
//     {
//         get => name;
//         set { name = value; OnPropertyChanged(nameof(Name)); }
//     }

//     private string level;
//     public string Level
//     {
//         get => level;
//         set { level = value; OnPropertyChanged(nameof(Level)); }
//     }


//     public FormViewModel()
//     {
//         SubmitCommand = new Command(OnSubmit);
//     }

//     private async void OnSubmit()
//     {
//         var formData = new
//         {
//             Id = this.Id,
//             Latitude = this.Latitude,
//             Longitude = this.Longitude,
//             Name = this.Name,
//             Level = this.Level
//         };

//         string json = JsonSerializer.Serialize(formData);
        
//         string filePath = Path.Combine(FileSystem.AppDataDirectory, "formData.json");
//         Console.WriteLine(filePath);

//         // Check if file exists, create it if not
//         if (!File.Exists(filePath))
//         {
//             File.Create(filePath).Dispose();
//         }        
        
//         await File.WriteAllTextAsync(filePath, json);
//     }

//     protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
//     {
//         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//     }


//     public event PropertyChangedEventHandler PropertyChanged;
// }
