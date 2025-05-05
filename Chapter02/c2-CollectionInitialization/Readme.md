# Initializing bound collections without freezing the UI
This example compliments a corresponding recipe from the book published by [Packt](https://www.packtpub.com/en-us?utm_source=github):

[.NET MAUI Cookbook: Build a full-featured app swiftly with MVVM, CRUD, AI, authentication, real-time updates, and more](https://www.amazon.com/NET-MAUI-Cookbook-full-featured-authentication-ebook/dp/B0DHV34WQ5)

**The recipe in the book covers the following topics:**
* How to asynchronously load data when a view is displayed using `EventToCommandBehavior` and an async command.
* Why a bound collection must implement `INotifyCollectionChanged` or be a `BindingList<T>` if you need to add/remove items.
* How to avoid performance issues when adding or removing a large number of items.
* Why calling an async method from a view model constructor to initialize a collection can lead to a deadlock.

**Note:** This example may not include all the points mentioned above. For complete details, please refer to the corresponding recipe in the book.

**Note1:** In order to be complianto for AOT on Windows, we need to add <LangVersion>preview</LangVersion> on the project file and for the for 
[ObservableProperty] we need to set the private field as "public partial" (instead of "private") and transform it in a property, adding "{ get; set; }".
The first letter of the (ex) field name, must be set a capital letter.

    [ObservableProperty]
    public partial ObservableCollection<Customer>? Customers { get; set; }

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(InitializeCommand))]
    public partial bool IsInitialized { get; set; }
