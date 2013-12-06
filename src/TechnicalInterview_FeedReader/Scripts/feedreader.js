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

        return this._mappedAjaxRequest(uri, "GET", null, function (feed) {
            return new Feed(
                feed.Id,
                feed.Name,
                feed.Url,
                feed.UnreadCount
            );
        });
    };

    FeedReader.prototype.searchFeeds = function(searchText) {
        var uri = this.apiUri + "/feeds/search";
        var data = { '': searchText };
        
        return this._mappedAjaxRequest(uri, "POST", data, function(story) {
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

    FeedReader.prototype.getStoriesForFeed = function(feedId) {
        var uri = this.apiUri + "/feeds/" + feedId + "/stories/";

        return this._mappedAjaxRequest(uri, "GET", null, function (story) {
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
        var uri = this.apiUri + "/feeds/";
        var data = { '': feedUrl };

        return this._mappedAjaxRequest(uri, "POST", data, function(feed) {
            return new Feed(
                feed.Id,
                feed.Name,
                feed.Url,
                feed.UnreadCount
            );
        });
    };

    FeedReader.prototype.getAllStories = function() {
        // Return a promise containing Ajax
        // response
    };

    FeedReader.prototype.refreshFeeds = function() {
        // Return a promise containing Ajax
        // response
    };

    FeedReader.prototype._mappedAjaxRequest = function(url, method, data, mapper) {
        var deferred = $.Deferred();

        $.ajax({
            url: url,
            method: method,
            data: data,
            //contentType: "application/json",
            success: function(data) {
                var mapped = data.indexOf ? $.map(data, mapper) : mapper(data);
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
        this.searchText = ko.observable();

        var self = this;

        self.showAddFeedDialog = function() {
            $('#addFeedModal').modal("show");
        };

        self.addFeed = function() {
            var feedUrl = self.addFeedModel.url();
            self.feedReader.addFeed(feedUrl).done(function (feed) {
                $('#addFeedModal').modal("hide");
                self.feeds.push(feed);
            });
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

        self.searchFeeds = function(evt) {
            var that = this;
            var searchText = self.searchText();

            self.feedReader.searchFeeds(searchText).done(function(data) {
                // TODO: Mark the "view all feeds" view as current
                self.stories.removeAll();
                $.each(data, function(idx, story) {
                    that.stories.push(story);
                });
            });
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