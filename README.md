# BangazonCLI

The Bangazon Command Line Interface allows a user to interact with the Bangazon database in the terminal environment.

### Installation of SQLite (if needed)

To get started, type the following command to check if you already have SQLite installed.

```sh
$ sqlite3
```

And you should see:

```sh
SQLite version 3.7.15.2 2014-08-15 11:53:05
Enter ".help" for instructions
Enter SQL statements terminated with a ";"
sqlite>
```

If you do not see above result, then it means you do not have SQLite installed on your machine. Follow the appropriate instructions below.

#### For Windows

Go to [SQLite Download page](http://www.sqlite.org/download.html) and download the precompiled binaries for your machine. You will need to download `sqlite-shell-win32-*.zip` and `sqlite-dll-win32-*.zip` zipped files.

Create a folder `C:\sqlite` and unzip the files in this folder which will give you `sqlite3.def`, `sqlite3.dll` and `sqlite3.exe` files.

Add `C:\sqlite` to your [PATH environment variable](http://dustindavis.me/update-windows-path-without-rebooting/) and finally go to the command prompt and issue `sqlite3` command.

#### For Mac

First, try to install via Homebrew:

```sh
brew install sqlite3
```

If not, download the package from above. After downloading the files, follow these steps:

```sh
$tar -xvzf sqlite-autoconf-3071502.tar.gz
$cd sqlite-autoconf-3071502
$./configure --prefix=/usr/local
$make
$make install
```

### Installation of Dotnet Core (if needed)

### For OSX Users:

Install .NET Core

https://www.microsoft.com/net/core#macos

### For Windows Users

https://www.microsoft.com/net/core#windows


## Steps to install the code
 - Create an environment variable for your database and test database files by adding the following statement to your shell script configuration ie .zshrc or .bashrc file
 - Replace the path to the locations of the files in your system

 ```
export BANGAZON_CLI="/Users/christophermiller/workspace/Bangazon/BangazonCLI/BangazonCLI/Data/BangazonCLI.db"
export BANGAZON_CLI_TEST="/Users/christophermiller/workspace/Bangazon/BangazonCLI/BangazonCLI.Tests/BangazonCLI_Test.db"
 ```
 - Save your shell script config and reload your terminal

 - Clone the repo to your local machine
 - Naviget to your desired directory and then use the following command 
 ```
 git clone git@github.com:StormyHares/BangazonCLI.git
 ```

 - Then:
 ```
 cd BangazonCLI/BangazonCLI/
 dotnet restore
 dotnet run
 ```



**Add Product To Order**<br>
To add a product:
1. Make a customer active in the system (option 2).
2. Select the option to add a product to an order (option 3).
3. All products that are not owned by the active customer will be displayed as options as long as there are quantity available to sell
4. After selecting an available product, the user will be prompted to enter the number of that product that they wih to purchase and the available quantity
5. After adding the product to the cart, the user will be presented with all of the available options again.

The user can type 'q' at any time to return to the reature menu


**Payment**<br>
To add a payment:
1. Select a customer (option 2).
2. Select the option to add a payment (option 1).
3. Follow the prompts, pressing enter when done typing the required information.
4. To exit prior to completion, type "q" and press enter.

Upon completion, the user will be taken back to the main menu.  Created payments are available in the Order process.

**Product**<br>
To add a product.
1. Select a customer (option 2).
2. Select the option to add a product (option 2).
3. Follow the prompts, pressing enter when done typng the required information
4. You will be prompted to create more products when done, enter Y or N as appropriate
5. You will be returned to the feature menu when done.

To Delete a product.
1. Select a customer (option 2).
2. Select the option to remove a product (option 5).
3. You will be presented a list of customer products, select the product you wish to delete or enter Q to
   return to the previous menu
4. Once a product is selected it will be deleted if it has never been placed on an order. The system will give
   you feedback if it has been successful.
5. You will be returned to the remove product menu, to exit to the previous menu type "q" and press enter.

**Complete an Order**<br>
To complete an order:
1. Select an Active Customer (option 2).
2. Select the option to Complete an Order (option 4).
3. Enter 'Y' to complete the Order or 'N' to return to Menu.
4. Select a Payment Option. 

Upon completion of Step 4, the user will be taken back to the main menu.

**View Stale Products**<br>
To view a list of products that meet ANY of the following criteria :
- Has never been added to an order, and has been in the system for more than 180 days
- Has been added to an order, but the order hasn't been completed, and the order was created more than 90 days ago
- Has been added to one, or more orders, and the order were completed, but there is remaining quantity for the product, and the product has been in the system for more than 180 days

1. From the main menu select option 4
2. All stale products will be displayed
3. If there are no stale products in your system and wish to check the functionality, run the following sql script in you database browser, save the database and repeat step 1
```

INSERT INTO Product
VALUES(null, 1, 'STALE REQ 1', 'Not ordered older than 180 days', 42134,  50, '2017-02-12');

INSERT INTO Product
VALUES(null, 2, "STALE REQ 2", "Added to an order but not purchased and the order is more than 90 days old", 42134,  33, '2017-10-02');

INSERT INTO Orders
VALUES(null, 1, null, '2017-10-08', null);

INSERT INTO OrderProduct
SELECT null, o.Id, p.Id
FROM Orders o, Product p
WHERE o.Created = '2017-10-08'
AND p.Title = 'STALE REQ 2';

INSERT INTO Product
VALUES(null, 3, "STALE REQ 3", "Purchased, but with remaining quantity and it is more than 180 days old", 42134,  2, '2017-01-12');

INSERT INTO Orders
VALUES(null, 1, 1, '2017-12-12', '2017-12-12');

INSERT INTO OrderProduct
SELECT null, o.Id, p.Id
FROM Orders o, Product p
WHERE o.Created = '2017-12-12'
AND p.Title = 'STALE REQ 3';
```
