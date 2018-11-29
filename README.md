Save the Kitty
==============

## Summary

This is my first ASP.NET MVC project. It is a JavaScript game that stores high scores in a MySQL database.

## Goal

Get the weapon and kill the monsters before they get to the kitty! Play it at:

https://savethekitty.azurewebsites.net/

## Design

Each level map is stored as an array of characters (see level.js). A table displaying the level is rendered dynamically based on the grid size of each level.

The monsters move in a random direction every half second. The kitty and weapon are stationary.

The user begins with 2 lives. The user loses a life by walking into a hole, allowing a monster to get the kitty, or encountering a monster unarmed.

After completing all the levels, it resets to level 1, but the monsters double in speed, and the user gains a life. The user also gains a life every 10 levels.

