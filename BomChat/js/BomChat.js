/// <reference path="knockout-2.1.0.js" />
/// <reference path="jquery.signalR-0.5.2.js" />
/// <reference path="jquery-1.7.2.js" />



function bomMessage(data) {
    this.message = ko.observable(data.message);
    this.user = ko.observable(data.user);
}


function AppViewModel() {
    var self = this;
    self.chatName = ko.observable("BomChat");
    self.userName = ko.observable("Jakob");
    self.newMessageText = ko.observable("");
    self.messages = ko.observableArray([]);



    // Operations
    self.addMessage = function () {
       

        $.ajax("/api/messages", {
            data: ko.toJSON({ message: this.newMessageText(), user: this.userName() }),
            type: "post", contentType: "application/json",
            success: function (result) {
               // self.messages.push(result);
                self.newMessageText("");
            }
        });


    };

    // Load initial state from server, convert it to message instances, then populate self.messages
    $.getJSON("/api/messages", function (allData) {
        var mappedMessages = $.map(allData, function (item) { return new bomMessage(item) });
        self.messages(mappedMessages);
    });


}

    // Activates knockout.js


        var viewModel = new AppViewModel();
    
        var myhub = $.connection.chat;

        ko.applyBindings(viewModel);



        $.extend(myhub, {
        addedMessage: function ( message) {
            viewModel.messages.push(message)
        }
    });

    $.connection.hub.start();

  