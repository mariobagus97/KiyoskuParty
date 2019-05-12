#ui-barcode-reader

When dealing with mobile apps, especially ones that involve e-commerce, often times, developers need to include a barcode scanner service right into their mobile apps. 

This sample demonstrates the barcode scanner service in Crosslight. Made from the ground up, the barcode scanner service supports more than 20+ types of barcodes around the world, ensuring maximum compatibility against multiple barcode types. You can even scan VCard QR codes with it. For more information, see [Working with Barcode Reader Service](http://developer.intersoftsolutions.com/display/crosslight/Working+with+Barcode+Reader+Service).

![image](http://developer.intersoftsolutions.com/download/attachments/20001278/barcode-scanner.png?version=1&modificationDate=1435139570813&api=v2)

#Supported Platforms

This sample works on the following platforms:

* iOS: iOS 8 and above
* Android: 4.0.3 and above (optimized for 5.0 and above)

This project requires Crosslight 5.0.5000.526 or higher. For more information, see [Crosslight 5.0 Release Notes](http://developer.intersoftsolutions.com/display/crosslight/Crosslight+5.0+Release+Notes).

#Project Structure

* BarcodeReader.Android.Material: Crosslight Android.Material project, works on phones and tablets.
* BarcodeReader.Core: Shared Portable Class Library project running Profile78.
* BarcodeReader.iOS: Crosslight iOS project, works on iPhones and iPad with Storyboard support.

#Features Overview

This sample showcases the following features:

* Support more than 20+ barcode types.
* Automatic barcode scanning.
* Very simple and straightforward API calls.
* Support async-await callbacks.
* Works on iOS and Android platform.

#Features Highlight
This sample is a modified Blank template generated using Crosslight Project Wizard.
Inside the **BarcodeReader.Core** project, open up **SimpleViewModel.cs** inside the **ViewModels** folder. Here, you'll find the code how to fire up the barcode scanner and also retrieve the result with async-await callbacks.

#Running the Sample

This sample is NuGet-enabled. For more information on restoring NuGet packages, check out this document: [Introduction to Crosslight NuGet Packages](http://developer.intersoftsolutions.com/display/crosslight/Introduction+to+Crosslight+NuGet+Packages#IntroductiontoCrosslightNuGetPackages-RestoringCrosslightPackages).

##Running on Mac
If you run this sample on Mac Xamarin Studio, all you have to do is just open the solution using Xamarin Studio and the NuGet packages will be restored automatically. Simply set one of the platform projects as start-up projects and run.

##Running on Windows
If you run this sample on Windows Visual Studio, right-click on the solution, then choose Restore NuGet packages. Wait until all the NuGet packages are restored, then simply set one of the platform projects as start-up projects and run.

#Relevant Links
* [Working with Barcode Reader Service](http://developer.intersoftsolutions.com/display/crosslight/Working+with+Barcode+Reader+Service)


Copyright © Intersoft Solutions.
