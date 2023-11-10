// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var table = document.getElementById("visitor-table");


document.addEventListener("DOMContentLoaded"){
    CheckPresentVisitors(){ }
}
function CheckPresentVisitors() {
    var visitors = @Model.Visitors;
        
        for (var i = 0, row; row = table.rows[i]; i++) {
            var tableEntry = (row.children[0].textContent)

            console.log(tableEntry, visitor.Name)
        }
    }



