$(function () {
    $(".demo1").bootstrapNews({
        newsPerPage: 3,
        autoplay: true,
        pauseOnHover:true,
        direction: 'up',
        newsTickerInterval: 2000,
        onToDo: function () {
            console.log(this);
        }
    });})