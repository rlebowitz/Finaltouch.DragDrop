# Finaltouch.DragDrop
A cross-platform drag and drop library for Blazor and .NET MAUI

I'll add more information here about how to set the different options later.  

Note about use on mobile devices:

One of the primary reasons for my developing this alternative drag and drop library for Blazor was to devise a cross-platform solution.  The HTML5 
Drag and Drop API does not work on IOS devices and thus limits its use if your goal is design across all the major platforms.  

My tests thus far indicate that my library works on the following:

1.  Chrome on Windows 11
2.  Edge on Windows 11
3.  Firefox on Android

Oddly enough, it doesn't work on Chrome on Android.  My phone has the lastest version (109) which, according to Can I Use supports the JavaScript features
I use to add drag and drop functionality, but it does not seem to work with this browser.  I'll add additional test results as I receive them.
