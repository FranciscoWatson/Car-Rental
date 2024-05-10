﻿// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
function updateCities() {
    var country = document.getElementById('countrySelect').value;
    fetch(`/DashboardPage?handler=Cities&country=${country}`)
        .then(response => response.json())
        .then(data => {
            var citySelect = document.getElementById('citySelect');
            citySelect.innerHTML = '<option value="">-- Select City --</option>';
            data.forEach(city => {
                var option = document.createElement('option');
                option.value = city.value;
                option.textContent = city.text;
                citySelect.appendChild(option);
            });
        });
}

function setupAndShowModal(reservationId, carId, startDate, endDate) {
    document.getElementById('reservationId').value = reservationId;
    document.getElementById('carId').value = carId;
    document.getElementById('newStartDate').value = startDate;
    document.getElementById('newEndDate').value = endDate;
    var updateModal = new bootstrap.Modal(document.getElementById('updateReservationModal'));
    updateModal.show();
}