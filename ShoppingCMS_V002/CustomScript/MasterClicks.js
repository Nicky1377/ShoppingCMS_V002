function All_Product_CL() {
   // alert("hello");
    $('#PageName').text("لیست همه ی محصولات");
    $('#LoadAll').load("https://localhost:44336/Product/Product_List");
}

function Add_Type_CL() {
    //alert("دسته بندی اصلی محصولات");
    $('#PageName').text("دسته بندی اصلی محصولات");
    $('#LoadAll').load("https://localhost:44336/MS/Add_Type");
}

function Add_MainCat_CL() {
   // alert("گروه اصلی محصولات");
    $('#PageName').text("گروه اصلی محصولات");
    $('#LoadAll').load("https://localhost:44336/MS/maincat");
}

function Add_SubCat_CL() {
   // alert("گروه محصولات");
    $('#PageName').text("گروه محصولات");
    $('#LoadAll').load("https://localhost:44336/MS/SubCat");
}

function Add_SCK_CL() {
    //alert("ویژگی های محصولات");
    $('#PageName').text("ویژگی های محصولات");
    $('#LoadAll').load("https://localhost:44336/MS/SubCatKey");
}