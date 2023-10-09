// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//$(document).ready(function () {
//    $("#selectArea").change(function () {
//        $("#selectProcesso").empty();
//        $.ajax({
//            type: 'GET',
//            url: '@Url.Action("LoadProcessos")',
//            dataType: 'json',
//            data: { id: $("#selectArea").val() },
//            success: function (processos) {
//                $("#selectProcesso").append('<option value="' + -1 + '">' +
//                    "Selectione o processo" + '</option');

//                $.each(processos, function (i, processo) {
//                    $("#selectProcesso").append('<option value="' + processo.Id + '">' +
//                        processo.Nome + '</option>');
//                });
//            },
//            error: function (ex);
//        });
//        return false;
//    })
//});

//var tableEmpresa = $('#tableProcesso td.empresa[data-row=227]').text();
//console.log("empresa: ", tableEmpresa);