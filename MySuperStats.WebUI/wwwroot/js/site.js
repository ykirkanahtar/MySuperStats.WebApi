// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
function getIdFromURL() {
    var urlArray = window.location.href.split('/');
    var id = urlArray[urlArray.length - 1];
    return id;
}

function getCultureFromURL() {
    var urlArray = window.location.href.split('/');
    var culture = urlArray[urlArray.length - 3];
    return culture;
}  

function GetLocalizedValue(pageUrl, value){
    var retValue = '';
    $.ajax({
        url: pageUrl + "?handler=LocalizedValue",
        dataType: "json", 
        type: "GET",
        async: false,
        data: {
            value: value
        },
        success: function (data) {
            retValue =  data;
        },
        error: function (x, y, z) {
            retValue =  value;
        }
    });
    return retValue;
}

function getTabulatorLocalization(){
    return {
        "tr":{
            "columns":{
                "name":"İsim", //replace the title of column name with the value "Name"
            },
            "ajax":{
                "loading":"Yükleniyor..", //ajax loader text
                "error":"Hata!", //ajax error text
            },
            "groups":{ //copy for the auto generated item count in group header
                "item":"eleman", //the singular  for item
                "items":"elemanlar", //the plural for items
            },
            "pagination":{
                "first":"İlk", //text for the first page button
                "first_title":"İlk Sayfa", //tooltip text for the first page button
                "last":"Son",
                "last_title":"Son Sayfa",
                "prev":"Önceki",
                "prev_title":"Önceki Sayfa",
                "next":"Sonraki",
                "next_title":"Sonraki Sayfa",
            },
            "headerFilters":{
                "default":"sütun filtresi...", //default header filter placeholder text
                "columns":{
                    "name":"filter name...", //replace default header filter text for column name
                }
            }
        },
        "en":{
            "columns":{
                "name":"Name", //replace the title of column name with the value "Name"
            },
            "ajax":{
                "loading":"Loading..", //ajax loader text
                "error":"Error!", //ajax error text
            },
            "groups":{ //copy for the auto generated item count in group header
                "item":"item", //the singular  for item
                "items":"item", //the plural for items
            },
            "pagination":{
                "first":"First", //text for the first page button
                "first_title":"First Page", //tooltip text for the first page button
                "last":"Last",
                "last_title":"Last Page",
                "prev":"Prev",
                "prev_title":"Previous Page",
                "next":"Next",
                "next_title":"Next Page",
            },
            "headerFilters":{
                "default":"Column Filter...", //default header filter placeholder text
                "columns":{
                    "name":"filter name...", //replace default header filter text for column name
                }
            }
        }        
    }
}
