// var currentDictionary = Directory.GetCurrentDirectory();
// var archivePath = Path.Combine(currentDictionary, "Archive");
// if (!Directory.Exists(archivePath)) Directory.CreateDirectory(archivePath);
// var userFolder = Path.Combine("C:", "Users", "admin");
// var files = Directory.Exists(userFolder)
//     ? Directory.GetFiles(userFolder)
//     : [];
// foreach (var file in files)
// {
//     var extension = Path.GetExtension(file);
//     if (extension == ".txt")
//     {
//         File.Copy(file, Path.Combine(archivePath, Path.GetFileName(file)), true);
//     }
// }

using CW6;

// Diary.Run();

    var manager = new MyJSON();
    manager.Run();
