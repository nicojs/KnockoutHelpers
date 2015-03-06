
$(function () {
  $.getJSON('/Home/Gebruiker')
    .done(function (gebruiker) {
      $('.js-examplejson').html(JSON.stringify(gebruiker));
      ko.applyBindings(ko.mapping.fromJS(gebruiker), $('.ko-user').element);
    });
});