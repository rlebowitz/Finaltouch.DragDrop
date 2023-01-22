# Finaltouch.DragDrop
A cross-platform drag and drop library for **Blazor** and **.NET MAUI**

I'll add more information here about how to set the different options later.  

This Drag and Drop library utilizes JavaScript interop in order to provide a 
fully cross-platform functionality for **Blazor** developers.  The HTML5 Drag and Drop
API does not support all mobile devices, most notably IOS devices.

The full technical details appear in my blog post:  https://blog.finaltouch.com/2023/01/a-cross-platform-drag-and-drop-library_17.html
There is a demo illustrating the library's use at https://rlebowitz.github.io/Finaltouch.DragDrop

## Supported Platforms Tested so Far
- IOS (Safari and Chrome Browsers)
- Android (Firefox, Samsung Internet and Chrome Browsers)
- Windows 11 (Chrome and Edge Browsers)

## Options
| Property | Default Value | Purpose |
| -------- | ------------- | ------- |
| containerClass | dd-container | Class applied to elements that hold draggable item |
| itemClass | dd-item | Class applied to elements that are draggable |
| handleClass | Empty string | Class applied to elements that serve as dragging handles |
| sort | true | Determines whether to sort elements as they are dropped in a container |
| clone | false | Determines whether the dragged element should be moved or just copied |