
## Usage

# Documentation

The documentation for this years Hackathon must be provided as a readme in Markdown format as part of your submission. 

You can find a very good reference to Github flavoured markdown reference in [this cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet). If you want something a bit more WYSIWYG for editing then could use [StackEdit](https://stackedit.io/app) which provides a more user friendly interface for generating the Markdown code. Those of you who are [VS Code fans](https://code.visualstudio.com/docs/languages/markdown#_markdown-preview) can edit/preview directly in that interface too.

Examples of things to include are the following.

## Summary

## Title- Travel Mania and Universal Trackor:

**Category:** Universal Trackor

What is the purpose of your module? What problem does it solve and how does it do that?

## Pre-requisites

1. Sitecore 9.1. Make sure Analytics is enable and xconnect service is up
2. Xamarin SDK setup and android emulator setup.We have verified the application with Android 8.1 – API 27.
3. Make sure that the emulator host file has sitecore9.1 instance host name and collection service url. You can refer https://android.stackexchange.com/questions/190627/edit-hosts-file-on-android-studio-messed-up-my-emulator 
4. Sitecore Universal Tracker 1.0.0 installed
5. check for any issue in the application using  https://sitecore.tracking.collection.service/status/ and https://sitecore.tracking.processing.service/status   



## Installation

Provide detailed instructions on how to install the module, and include screenshots where necessary.

1.Install Sitecore package which includes:
  a.	Feature tracking project templates
  b.	Foundation tracking project templates
  c.	Project Templates
  d.	Marketing items
  e.	Tracking settings Item
  f.	Content tree with home item and few child items

2.Navigate to /sitecore/system/Settings/Foundation/Tracker/Tracker Setting Items/Tracker Settings Mobile App. Here you can select the goal, event and channel. If  ‘Is Tracking enabled’ is un-checked then no event or goal will be triggered.



## Usage


**Module Purpose:** To Track Sitecore Mobile App analytics data to Sitecore

As a business we might have different systems to handle different entities of our operations but it makes more sense if business can get a overview of all systems in one place which helps them to take strategic decisions.

Sitecore comes with OOTB Analytics but what about when we want to track some non sitecore application data to Sitecore- how we get this data into Sitecore Analytics?
Universal tracking is the answer for that, this module is pretty new and it was launched last year and the main foundation of this Module is to track non- Sitecore app data to Sitecore Analytics (via xConnect)

This module is to show how we can leverage Universal Tracking to track analytics data from non Sitecore base based application to Sitecore, there are several things which we can track with this, some of the examples for ref:

1) Channels
2) Goals
3) Events and etc.

In this case we have Mobile App (focused on travel business) using Xamarine which has 2 pages:
1) Home page (Landing page)- This includes Banner and list of travel destinations that are available for end users to select from.
2) Detail page (Destination travel detail page)

Now when user open this Mobile App (Travel Mania) business wants to track the page views, the channel from where the visit has been made, if any Goals has been trigerred based on predefined events and so on.
Also- the source of data would be Sitecore in this case which means contents for Mobile App home page and inner pages (destinatiion pages) would come directky from Sitecore.

## How does the end user/developer use the Module?

In order to solve this problem we will use Universal tracking to sync data from Mobile App(based on Xamarine) and push it back to xDB using xConnect.
As part of this we would also create following Marketing Items in Sitecore under Sitecore Marketing Control Panel which includes:
1) Channel
2) Goals and Events.

MobileApp project is hosted as Feature layer and performs all business rules and call to Sitecore.Foundation.Tracker project is made to push data to xDB on load of home page and destination detail page.

This modules includes a foundation project- Sitecore.Foundation.Tracker which facilitates tracking channel, goals and events data and using xConnect it gets saved to xDB.

Provide documentation  about your module, how do the users use your module, where are things located, what do icons mean, are there any secret shortcuts etc.


## Video


[![Sitecore Hackathon Video Embedding Alt Text](https://img.youtube.com/vi/EpNhxW4pNKk/0.jpg)](https://youtu.be/Qqm7Fq0GC30)
