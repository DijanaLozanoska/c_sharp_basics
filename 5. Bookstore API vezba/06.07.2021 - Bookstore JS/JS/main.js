// const GetAllCategories = new Promise((resolve, reject) => {
//   $.ajax({
//     type: "GET",
//     url: "https://localhost:5001/api/Category",
//     contentType: "application/json; charset=utf-8",
//     dataType: "json",
//     success: function (data) {
//       resolve(data);
//     }, //End of AJAX Success function
//     failure: function (data) {
//       reject(data.responseText);
//     }, //End of AJAX failure function
//     error: function (data) {
//       reject(data.responseText);
//     }, //End of AJAX error function
//   });
// });

function callModal(bookID) {
  let bookModal = $("#myModal");
  GetBook(bookID)
    .then((result) => {
      $(".modal-title").text(result.title);
      $(".modal-body > img").attr("src", result.imageUrl);
      $("#author").text(result.author);
      $("#issueDate").text(convertDate(result.issueDate));
      $(".modal-body > dl > dd").text(result.description);
      $("#price").text(result.price);
      let UpdateBtn = $("#Update");
      UpdateBtn.attr("href", "./Books/AddOrUpdateBook.html?" + result.bookID);
      let DeleteBtn = $("#Delete");
      DeleteBtn.click(function () {
        DeleteBook(result.bookID)
          .then((result) => {
            console.log(result);
          })
          .catch((err) => {
            console.log("DeleteBtn/DeleteBook", err);
            location.reload();
          });
      });
      let myModal = new bootstrap.Modal(bookModal);
      myModal.show();
    })
    .catch((err) => {
      console.log("myModal/GetBook", err);
    });
}
function GetBooksByCategoryID(categoryID, count) {
  console.log("GetBooksByCategoryID", categoryID, count);
  let numOfBooks = count != null ? "/" + count : "";
  return new Promise((resolve, reject) => {
    $.ajax({
      type: "GET",
      url:
        "https://localhost:5001/api/Books/ByCategoryID/" +
        categoryID +
        numOfBooks,
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      success: function (data) {
        resolve(data);
      }, //End of AJAX Success function
      failure: function (data) {
        reject(data.responseText);
      }, //End of AJAX failure function
      error: function (data) {
        reject(data.responseText);
      }, //End of AJAX error function
    });
  });
}
const GetAllCategories = new Promise((resolve, reject) => {
  $.ajax({
    type: "GET",
    url: "https://localhost:5001/api/Category",
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function (data) {
      resolve(data);
    }, //End of AJAX Success function
    failure: function (data) {
      reject(data.responseText);
    }, //End of AJAX failure function
    error: function (data) {
      reject(data.responseText);
    }, //End of AJAX error function
  });
});
function GetBook(bookID) {
  return new Promise((resolve, reject) => {
    $.ajax({
      type: "GET",
      url: "https://localhost:5001/api/Books/" + bookID,
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      success: function (data) {
        resolve(data);
      }, //End of AJAX Success function
      failure: function (data) {
        reject(data.responseText);
      }, //End of AJAX failure function
      error: function (data) {
        reject(data.responseText);
      }, //End of AJAX error function
    });
  });
}
function insertCards(categories, tagID) {
  $(tagID).empty();
  categories.forEach((category) => {
    let description =
      category.description.length > 100
        ? category.description.substring(0, 100) + "..."
        : category.description;
    let title =
      category.title.length > 20
        ? category.title.substring(0, 20) + "..."
        : category.title;

    $(tagID).append(
      `<div class="card">
          <img src="${category.imageUrl}" class="card-img-top" alt="...">
          <div class="card-body">
          <h5 class="card-title"> ${title}</h5>
          <p class="card-text">${description}</p>
          <button class="btn btn-primary" id="book${category.bookID}">Details</button>
          </div>
          </div>`
    );
    $("#book" + category.bookID).click(() => {
      callModal(category.bookID);
    });
  });
}

function DeleteBook(bookID) {
  return new Promise((resolve, reject) => {
    $.ajax({
      type: "Delete",
      url: "https://localhost:5001/api/Books/Delete/" + bookID,
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      success: function (data) {
        resolve(data);
      }, //End of AJAX Success function
      failure: function (data) {
        reject(data.responseText);
      }, //End of AJAX failure function
      error: function (data) {
        reject(data.responseText);
      }, //End of AJAX error function
    });
  });
}
function convertDate(date) {
  date = new Date(date);
  year = date.getFullYear();
  month = date.toLocaleString("default", { month: "long" });
  dt = date.getDate();
  if (dt < 10) {
    dt = "0" + dt;
  }
  if (month < 10) {
    month = "0" + month;
  }
  return dt + "-" + month + "-" + year;
}
function formatDate(date) {
  var d = new Date(date),
    month = "" + (d.getMonth() + 1),
    day = "" + d.getDate(),
    year = d.getFullYear();
  if (month.length < 2) month = "0" + month;
  if (day.length < 2) day = "0" + day;
  return [year, month, day].join("-");
}
