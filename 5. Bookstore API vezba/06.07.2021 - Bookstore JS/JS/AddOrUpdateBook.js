$(document).ready(function () {
  let url = window.location.href;
  let bookID = url.substring(url.indexOf("?") + 1);
  console.log("BookID is:" +bookID);
});
