var FeedReader = (function ($, ko) {
    
    ///////////////////////////////////////
    /// FEED CLASS
    ///////////////////////////////////////

    var Feed = function(id, name, url, unreadCount) {
        this.id = ko.observable(id);
        this.name = ko.observable(name);
        this.url = ko.observable(url);
        this.unreadCount = ko.observable(unreadCount);
    };
    
    ////////////////////////////////////////
    /// STORY CLASS
    ////////////////////////////////////////

    var Story = function(id, title, body, url, publishedOn, isRead) {
        this.id = ko.observable(id);
        this.title = ko.observable(title);
        this.publishedOn = ko.observable(publishedOn);
        this.isRead = ko.observable(isRead);
    };

    ////////////////////////////////////////
    /// FEEDREADER CLASS
    ////////////////////////////////////////

    var FeedReader = function(apiUri) {
        this.apiUri = apiUri;
    };

    FeedReader.prototype.getFeeds = function() {
        // Return a promise containing Ajax
        // response
    };

    FeedReader.prototype.getStoriesForFeed = function(feedId) {
        // Return a promise containing Ajax
        // response
    };

    FeedReader.prototype.addFeed = function(feedUrl) {
        // Return a promise containing Ajax 
        // response
    };

    FeedReader.prototype.getAllStories = function() {
        // Return a promise containing Ajax
        // response
    };

    FeedReader.prototype.refreshFeeds = function() {
        // Return a promise containing Ajax
        // response
    };
    
    ////////////////////////////////////////
    /// MAIN VIEW MODEL CLASS
    ////////////////////////////////////////

    var MainViewModel = function(apiUri) {
        this.feedReader = new FeedReader(apiUri);
        this.feeds = ko.observableArray();
        this.stories = ko.observableArray();
    };

    MainViewModel.prototype.showAddFeedDialog = function() {
        // Use Bootstrap API to show the "Add Feed"
        // dialog
    };

    MainViewModel.prototype.addFeed = function() {
        // Use FeedReader class to add the feed, then
        // add the returned Feed object to the list
        // of feeds
    };

    MainViewModel.prototype.refreshFeeds = function() {
        // Use FeedReader class to refresh all the
        // feeds
    };

    MainViewModel.prototype.getStories = function() {
        // Use FeedReader class to get list of stories
        // for the currently selected feed
    };

    MainViewModel.prototype.viewStory = function() {
        // Handles a click on an entry in the story list on the screen
        // and displays the story body
    };

    MainViewModel.prototype._getFeeds = function() {
        // Helper method used to load the initial list
        // of feeds the user has subscribed to
    };

    ////////////////////////////////////////
    /// MODULE EXPORTS
    ////////////////////////////////////////
    
    return {
        "FeedReader": FeedReader,
        "Feed": Feed,
        "Story": Story,
        "MainViewModel": MainViewModel
    };
})(jQuery, ko);