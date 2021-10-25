$(document).ready(function () {
  GetAllCategories.then((result) => {
    console.log("result", result);

    let counter = 0;
    result.forEach((category) => {
      //   console.log("CategoryDebug", category); /// for debugging purposes
      if (counter === 0) {
        $("#CategoryDD").append(
          `<option value="${category.categoryID}" selected>${category.categoryName}</option>`
        );
      } else {
        $("#CategoryDD").append(
          `<option value="${category.categoryID}">${category.categoryName}</option>`
        );
      }
      counter++;
    });

    GetBooksByCategoryID($("#CategoryDD").find(":selected").val(), 1)
      .then((result) => {
        insertCards(result.reverse(), "#top-books");
      })
      .catch((err) => {
        console.log(err);
      });
    $("#CategoryDD").change(function () {
      let categoryID = this.value;
      GetBooksByCategoryID(categoryID, 4)
        .then((result) => {
          insertCards(result.reverse(), "#top-books");
        })
        .catch((err) => {
          console.log(err);
        });
    });
  }).catch((err) => {
    console.log("Error", err);
  });
});
