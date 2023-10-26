function sortByName() {
    sortList('data-name');
}

// Function to sort by city
function sortByCity() {
    sortList('data-city');
}

// General function to sort list
function sortList(attribute) {
    const list = document.getElementById('restaurant_data');
    const items = Array.from(list.querySelectorAll('tr'));

    items.sort((a, b) => {
        return a.getAttribute(attribute).localeCompare(b.getAttribute(attribute));
    });

    // Clear and re-add sorted items
    list.innerHTML = '';
    items.forEach(item => list.appendChild(item));
}

// $(document).ready(function () {
//     $("#searchInput").on("keyup", function () {
//         var value = $(this).val().toLowerCase();
//         $("#restaurant_data tr").filter(function () {
//             $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
//         });
//     });
// });

