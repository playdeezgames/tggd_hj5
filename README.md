# The Grumpy GameDev's Honest Jam V Entry

The Grumpy GameDev's Repository for his Honest Jam V

## tggd_hj5

This is the UI. It can have its own state separate from the World's state. Avoid putting UI information into the World information.

## HJ5.Business

World matches up with HJ5.Data's WorldData. Subobject will match WorldData subojects. This is where all of the logic for the game exists. Avoid revealing details about the data representation to the UI.

## HJ5.Data

WorldData and other components thereof are simply models for persisting data to and from the file system.

