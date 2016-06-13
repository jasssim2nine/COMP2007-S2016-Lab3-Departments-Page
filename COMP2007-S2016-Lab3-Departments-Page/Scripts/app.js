/*
 *  Author Name : Jasim Khan
 * student id : 200263011
 * date : 13-06-16
 * custom javascript goes in here.
 */
 

//custom jquery script for confirmation before deleting any record from student or departments table...
$(document).ready(function () {

    console.log("app started");

    $("a.btn.btn-danger.btn-sm").click(function () {
        return confirm("Are you sure you want to delete this record?");
    });
});