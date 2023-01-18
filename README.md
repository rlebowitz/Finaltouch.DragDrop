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

The library doesn't work on:
1.  Chrome on Android (v.109)
2.  Opera on Android (v.72)
3.  Samsung Internet (v.19)

Can I Use says that all these latter browsers support both the requestAnimationFrame and pointer events, though it appears that the support is very recent (Oct-Dec 2022)  I'm wondering if there are still bugs in the Chromium mobile engine that are affecting this.  
