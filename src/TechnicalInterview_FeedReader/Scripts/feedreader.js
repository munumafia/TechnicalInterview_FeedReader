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

    var Story = function(id, title, body, url, publishedOn, isRead, author) {
        this.id = ko.observable(id);
        this.title = ko.observable(title);
        this.body = ko.observable(body);
        this.publishedOn = ko.observable(publishedOn);
        this.isRead = ko.observable(isRead);
        this.author = ko.observable(author);
    };

    ////////////////////////////////////////
    /// FEEDREADER CLASS
    ////////////////////////////////////////

    var FeedReader = function(apiUri) {
        this.apiUri = apiUri;
    };

    FeedReader.prototype.getFeeds = function () {
        var uri = this.apiUri + "/feeds/";
        return this._mappedAjaxRequest(uri, "GET", function(feed) {
            return new Feed(
                feed.Id,
                feed.Name,
                feed.Url,
                feed.UnreadCount
            );
        });
    };

    FeedReader.prototype.getStoriesForFeed = function(feedId) {
        var uri = this.apiUri + "/feeds/" + feedId + "/stories/";
        return this._mappedAjaxRequest(uri, "GET", function(story) {
            return new Story(
                story.Id,
                story.Title,
                story.Body,
                story.Url,
                story.PublishedOn,
                story.IsRead,
                ""
            );
        });
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

    FeedReader.prototype._mappedAjaxRequest = function(url, method, mapper) {
        var deferred = $.Deferred();

        $.ajax({
            url: url,
            method: method,
            contentType: "application/json",
            success: function(data) {
                var mapped = $.map(data, mapper);
                deferred.resolve(mapped);
            },
            failure: function() {
                deferred.reject();
            }
        });

        return deferred.promise();
    };
    
    ////////////////////////////////////////
    /// ADD FEED VIEWMODEL CLASS
    ////////////////////////////////////////

    var AddFeedViewModel = function() {
        this.url = ko.observable();
    };
    
    ////////////////////////////////////////
    /// MAIN VIEWMODEL CLASS
    ////////////////////////////////////////

    var MainViewModel = function(apiUri) {
        this.feedReader = new FeedReader(apiUri);
        this.feeds = ko.observableArray();
        this.stories = ko.observableArray();
        this.addFeedModel = new AddFeedViewModel();
        this.currentFeed = ko.observable();
        this.currentStory = ko.observable(new Story());

        var self = this;

        self.showAddFeedDialog = function() {
            $('#addFeedModal').modal("show");
        };

        self.addFeed = function() {
            // Use FeedReader class to add the feed, then
            // add the returned Feed object to the list
            // of feeds    
        };
        
        self.closeAddFeedDialog = function () {
            // Use Bootstrap API to close the "Add Feed" 
            // dialog
        };
        
        self.refreshFeeds = function () {
            // Use FeedReader class to refresh all the
            // feeds
        };
        
        self.getStories = function (feed) {
            var that = this;

            var id = feed.id();
            self.feedReader.getStoriesForFeed(id).done(function (stories) {
                that.stories.removeAll();
                $.each(stories, function (idx, story) {
                    that.stories.push(story);
                });
            });
        };
        
        self.getStories = function (feed) {
            var id = feed.id();
            self.feedReader.getStoriesForFeed(id).done(function (stories) {
                self.stories.removeAll();
                $.each(stories, function (idx, story) {
                    self.stories.push(story);
                });
            });
        };
        
        self.viewStory = function (story) {
            // Handles a click on an entry in the story list on the screen
            // and displays the story body
            self.currentStory(story);
        };
        
        self._getFeeds = function () {
            var that = this;

            self.feedReader.getFeeds().done(function (data) {
                $.each(data, function (idx, feed) {
                    that.feeds.push(feed);
                });
            });
        };
        
        this._getFeeds();
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