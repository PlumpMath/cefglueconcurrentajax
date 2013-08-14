cefgluesimpleajax
==========

Simple client based on http://xilium.bitbucket.org/cefglue for MS Windows, Chromium Embedded Framework version 3.1453.1255 included. 

Why I've created this repo.
==========

There is cool framework for developing desktop applications using HTML+CSS+JS for interface and C++ for low-level routines http://en.wikipedia.org/wiki/Chromium_Embedded_Framework Also you can develop those apps using .NET see http://xilium.bitbucket.org/cefglue/ But I faced some troubles compiling their source code. This repo shows how to implement communication between JS and .NET using AJAX asynchronous requests.

Building tips
==========

I use MS VisualStudio 2012. Don't forget to "Set as default" CefGlue.Client project(using right mouse button). And change active solution platform to x86 in Build->Configuration window... window.