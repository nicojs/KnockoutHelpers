Knockout helper for ASP.NET MVC
===============================

Introducing DRY (Don't repeat yourself) principles and type safety to knockoutjs for ASP.NET MVC applications.

## Examples

### ViewModel class (C#):

```c#
public class UserJson : JsonViewModel
    {
        public UserJson()
        { }

        public int Id { get; set; }
        public string Name { get; set; }
        public AccountProvider Account { get; set; }
        public List<HobbyJson> Hobbies { get; set; }
    }
public class HobbyJson : JsonViewModel
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }
 public enum AccountProvider
    {
        Facebook,
        Google,
    }
```

### Json:
```javascript
{"Id":1,"Name":"jan","Account":1,"Hobbies":[{"Name":"Coden","Score":10},{"Name":"Sporten","Score":5}]}
```

### Glue it all together:
```javascript
    $(function () {
      $.getJSON('/Home/User')
        .done(function (gebruiker) {
          $('.js-voorbeeldjson').html(JSON.stringify(gebruiker));
          ko.applyBindings(ko.mapping.fromJS(gebruiker), $('.ko-gebruiker').element);
        });
    });
```

### Type safety in the view:
Using lambda's (like Html.TextboxFor, Html.LabelFor, etc)

This: ```Model.SpanWithBindingFor(g => g.ScreenName)```
Result: ```<span data-bind="text: Name"/>```

### DRY If / else

Type-save if-else and switch statements in your template. Changing a property name will result in a red build! Awesome!

This:
```c#
                using (var stmnt = Ko.IfFor(g => g.Account, AccountProvider.Google))
                {
                    <img src="@Links.Content.images.google_JPG" alt="google" />;
                stmnt.Else();

                    <img src="@Links.Content.images.facebook_JPG" alt="facebook" />;
                }
```

Result:
```html
                <!-- ko if: Account() === 1 -->
                    <img src="/Content/images/google.JPG" alt="google" />
                <!-- /ko -->
                <!-- ko ifnot: Account() === 1 -->
                    <img src="/Content/images/facebook.JPG" alt="facebook" />
                <!-- /ko -->
```

## More

Download the source code and run the application. Play with it:
* ForEachFor()
* SwitchFor(Enum/String lambda)
* stmnt.Case(EnumType.EnumValue)
* Typesafe knockout expressies opstellen

## How does it work?

It uses another base view page for your application. It is defined in the web.config of your views folder:

```xml
 <system.web.webPages.razor>
 <host factoryType="System.Web.Mvc.MvcWebRazorHostFactory, System.Web.Mvc, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
 <pages pageBaseType="InfoSupport.KnockoutHelpers.Views.WebViewPage">
 <namespaces>
```

Instead of retrieving the actual data in your view, you retrieve a knockout template:

```c#
return View(new KnockoutViewModel<UserJson>());
```

Use the KnockoutViewModel to define your template.
```c#
@model KnockoutViewModel<UserJson>
```

Use Ko.IfFor, Ko.ForEachFor, stmnt.Else, Ko.SwitchFor. For all C# statements there is a knockout template equivalent

## Still to do..

* Add clientside validation

