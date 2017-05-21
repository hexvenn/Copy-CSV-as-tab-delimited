# Copy-CSV-as-tab-delimited
This is a little shell extension that will copy your CSV file as a tab-delimited text. Wonderful with spreadsheets!

Binary:
https://github.com/hexvenn/Copy-CSV-as-tab-delimited/releases/

Prerequisites:
 - Excel needs to be set as default program for CSV files
 - .NET 4.6

Instructions:
 - Get the binary and place it somewhere it won't bother you (it has to stay there)
 - Click the executable - you should see a dialog saying that the extension has been registered
 - Right click your CSV file and choose "Copy tab-delimited"
 - Paste into spreadsheet

 Issues:
 - Excel needs to be the default program for CSV files as CSV has no default ProgID otherwise (we don't actually need to use Excel)
 - May not work with very large files