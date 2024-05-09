Welcome to my Scriptable Object-based Inventory System!

This system leverages Scriptable Objects to efficiently manage items, inventory, and shops in your game. Here's a quick overview of its key features:

**Inventory Management:**
- Each in-game item is represented by a Scriptable Object called Item, containing crucial details such as name, icon, and price.
- The player's inventory is managed by another Scriptable Object named Inventory. It supports setting a maximum inventory size and handles item addition, removal, and quantity checks automatically.

**Shop Interaction:**
- Our system includes a Shop Scriptable Object where players can browse and purchase items.
- Purchasing an item deducts the required currency and adds the item to the player's inventory, provided there's enough space available.

**Tabbed Inventory System:**
- To enhance organization, the player's inventory features tabs categorizing items based on different criteria. This makes it effortless for players to locate desired items quickly.

**Automatic Item Usage:**
- Enjoy seamless gameplay with automatic item usage. When a player consumes an item from their inventory, it's immediately removed, eliminating the need for manual inventory management.
