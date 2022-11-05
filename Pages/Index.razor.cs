using Microsoft.AspNetCore.Components;
using PersonalSite.Models;

namespace PersonalSite.Pages;

public partial class Index : ComponentBase
{
    private readonly List<Project> _projects = new();

    protected override void OnInitialized()
    {
        _projects.Add(new Project
        {
            Title = "Rootines",
            Description =
                "It is a platform to help children with certain conditions (autism, epilepsy, mental health etc.) " +
                "created from scratch in Blazor Server. Has user, role management, multiple tracking options for children" +
                "with insights reporting per day, week and month. Authentication is handled by Auth0 with custom actions and AD support " +
                "for facilities. Uses Azure Functions and Event Grid for the notification system, all hosted and managed on Azure.",
            Images = new List<string>{"images/rootines.png","images/rootines-2.png","images/rootines-3.png"}
        });
        _projects.Add(new Project
        {
            Title = "ZBet",
            Description =
                "The goal of this project was to create a site where users could register and login to a betting site. " +
                "The site must have full administrative support for teams, stadiums, games, users and global bets. " +
                "It was also important to make it as easy to administer and lightweight to reduce hosting costs. " +
                "It's fully responsive, works well on laptop, tablet and mobile. It's a PWA application, so the user " +
                "can install it on any machine for ease of usage.",
            Images = new List<string>{"images/zbets.png", "images/zbets-2.png", "images/zbets-3.png"}
        });
        _projects.Add(new Project
        {
            Title = "Thinkpod",
            Description =
                "Worked on kickstarting a new social platform to help people connect in a more casual/fun and " +
                "professional way. Was leading the team of frontend engineers to create the UI for the platform in VueJs." +
                " Had to develop a news feed, notification system, chat with direct messages and groups, payment system " +
                "with Stripe and authentication with Auth0. ",
            Images = new List<string>{"images/thinkpod.png","images/thinkpod-2.png","images/thinkpod-3.png","images/thinkpod-4.png"}
        });
        _projects.Add(new Project
        {
            Title = "Application Tracker",
            Description =
                "Small Windows application that tracks Excel usage on your computer. Has a reporting side where the user" +
                "can view and manage usage and export the details. Data is stored only locally in a SQLite database." +
                "Runs in the background using minimal resources.",
            Images = new List<string>{"images/tracker.png"}
        });
    }
}