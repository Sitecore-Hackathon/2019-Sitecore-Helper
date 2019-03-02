# Documentation

The documentation for this years Hackathon must be provided as a readme in Markdown format as part of your submission. 

You can find a very good reference to Github flavoured markdown reference in [this cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet). If you want something a bit more WYSIWYG for editing then could use [StackEdit](https://stackedit.io/app) which provides a more user friendly interface for generating the Markdown code. Those of you who are [VS Code fans](https://code.visualstudio.com/docs/languages/markdown#_markdown-preview) can edit/preview directly in that interface too.

Examples of things to include are the following.


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

Does your module rely on other Sitecore modules or frameworks?

- List any dependencies
- Or other modules that must be installed
- Or services that must be enabled/configured

## Installation

Provide detailed instructions on how to install the module, and include screenshots where necessary.

1. Use the Sitecore Installation wizard to install the [package](#link-to-package)
2. ???
3. Profit

## Configuration

How do you configure your module once it is installed? Are there items that need to be updated with settings, or maybe config files need to have keys updated?

Remember you are using Markdown, you can provide code samples too:

```xml
<?xml version="1.0"?>
<!--
  Purpose: Configuration settings for my hackathon module
-->
<configuration xmlns:patch="http://www.sitecore.net/xmlconfig/">
  <sitecore>
    <settings>
      <setting name="MyModule.Setting" value="Hackathon" />
    </settings>
  </sitecore>
</configuration>
```

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

Please provide a video highlighing your Hackathon module submission and provide a link to the video. Either a [direct link](https://www.youtube.com/watch?v=EpNhxW4pNKk) to the video, upload it to this documentation folder or maybe upload it to Youtube...

[![Sitecore Hackathon Video Embedding Alt Text](https://img.youtube.com/vi/EpNhxW4pNKk/0.jpg)](https://www.youtube.com/watch?v=EpNhxW4pNKk)
