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

  //toggle cell value on click
  var tickToggle = function(e, cell, value, data){
    cell.trigger("editval", !value);
  }

function findAndRemoveElementFromArray(array, playerid){
    for (i = 0; i < array.length; i++){
        if(array[i].playerid == playerid){
            array.splice(i, 1);
        }
    }
}

function getTeamPlayers(pageUrl, culture, team, matchType, tableName) //matchType : basketball, football
{
    var table = new Tabulator("#" + tableName, {
        height:500, // set height of table (in CSS or here), this enables the Virtual DOM and improves render speed dramatically (can be any valid css height value)
        layout:"fitColumns", //fit columns to width of table (optional)
        responsiveLayout:true, // enable responsive layouts
        pagination : "local",
        ajaxLoader: true,
        index: "playerid",
        paginationSize: 15,
        langs: getTabulatorLocalization(), 
        columns:[ //Define Table Columns
          {title:"playerid", field:"playerid", visible:false},
          {title: GetLocalizedValue(pageUrl, "FirstNameLastName"), field:"name"},
          {title:GetLocalizedValue(pageUrl, "AddToTeam"), field:"haschecked", formatter:"tickCross"},
        ],      
        rowClick:function(e, row){ //trigger an alert message when the row is clicked
          //alert("Row " + row.getData().id + " Clicked!!!!");
          var playerid = row.getData().playerid;
          var name = row.getData().name;
          var hasChecked = !row.getData().haschecked;
          table.updateData([{playerid:playerid, name:name, haschecked: hasChecked}]); 
          if(hasChecked){
              if(matchType == 'football')
                addToFootballArray(team, playerid, name);
              else if(matchType == 'basketball')
                addToBasketballArray(team, playerid, name);
          }
          else{
            findAndRemoveElementFromArray(team, playerid);
          }
        },
      });
      table.setData(pageUrl + "?handler=Players");
      table.setLocale(culture);

      return table;
}

function getStatsType(pageUrl, statsData){
    var table = new Tabulator("#selectStats", {
    height:500, // set height of table (in CSS or here), this enables the Virtual DOM and improves render speed dramatically (can be any valid css height value)
    layout:"fitColumns", //fit columns to width of table (optional)
    responsiveLayout:true, // enable responsive layouts
    pagination : "local",
    ajaxLoader: true,
    index: "id",
    paginationSize: 15,
    langs: getTabulatorLocalization(), 
    columns:[ //Define Table Columns
      {title:"id", field:"id", visible:false},
      {title: GetLocalizedValue(pageUrl, "StatType"), field:"name"},
      {title:GetLocalizedValue(pageUrl, "Select"), field:"haschecked", formatter:"tickCross"},
    ],    
    rowClick:function(e, row){ //trigger an alert message when the row is clicked
      //alert("Row " + row.getData().id + " Clicked!!!!");
      var id = row.getData().id;
      var name = row.getData().name;
      var hasChecked = !row.getData().haschecked;
      table.updateData([{id:id, name:name, haschecked: hasChecked}]); 
    },
  });

  table.setData(statsData);
  return table;
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

function userFootballStats(playerid, name, teamid, goal, owngoal, penaltyscore, missedpenalty, assist, savegoal, concedegoal){
    this.playerid = playerid;
    this.name = name;
    this.teamId = teamid;
    this.goal = goal;
    this.owngoal = owngoal;
    this.penaltyscore = penaltyscore;
    this.missedpenalty = missedpenalty;
    this.assist = assist;
    this.savegoal = savegoal;
    this.concedegoal = concedegoal;
}

function userBasketballStats(playerid, name, teamid, onepoint, twopoint, missingonepoint, missingtwopoint,rebound, stealball, looseball, assist, interrupt){
    this.playerid = playerid;
    this.name = name;
    this.teamId = teamid;
    this.onepoint = onepoint;
    this.twopoint = twopoint;
    this.missingonepoint = missingonepoint;
    this.missingtwopoint = missingtwopoint;
    this.rebound = rebound;
    this.stealball = stealball;
    this.looseball = looseball;
    this.assist = assist;
    this.interrupt = interrupt;
}

function addToBasketballArray(array, playerid, name){
    var u = new userBasketballStats(playerid, name,0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
    array.push(u);
  }

  function addToBasketballStats(array, playerid, teamId, onepoint, twopoint, missingonepoint, missingtwopoint, rebound, stealball, looseball, assist, interrupt){
    var u = new userBasketballStats(playerid, name,teamId, onepoint, twopoint, missingtwopoint, missingtwopoint, rebound, stealball, looseball, assist, interrupt);
    array.push(u);
  }  

function addToFootballStats(array, playerid, teamId, goal, owngoal, penaltyscore, missedpenalty, assist, savegoal, concedegoal){
    var u = new userFootballStats(playerid, name, teamId, goal, owngoal, penaltyscore, missedpenalty, assist, savegoal, concedegoal);
    array.push(u);
}  

function addToFootballArray(array, playerid, name){
    var u = new userFootballStats(playerid, name, 0, 0, 0, 0, 0, 0, 0, 0);
    array.push(u);
}
