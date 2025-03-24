const apiKey = '0978e2504fb80d1dbb02f3e18e711672';
const searchBar = document.querySelector('.search-bar');
const weatherDetails = document.querySelector('.weather-details');
const cityName = document.querySelector('.city-name');
const temperature = document.querySelector('.temperature');
const weatherIcon = document.querySelector('.icon');
const weatherDescription = document.querySelector('.weather-description');
const weatherContainer = document.querySelector('.weather-container');
const hourlyForecastContainer = document.querySelector('.hourly-forecast');
const addFavoriteButton = document.querySelector('.add-favorite');
const favoritesList = document.querySelector('.favorites-list');
const sendButton = document.querySelector('.send-button');
const messageBox = document.querySelector('.message-box');
const notification = document.querySelector('.notification');

const navButtons = document.querySelectorAll('.nav-button');
const homeSection = document.getElementById('home');
const contactSection = document.getElementById('contact');
const humiditySection = document.getElementById('humidity');
const precipitationSection = document.getElementById('precipitation');
const favoritesSection = document.getElementById('favorites');
const aboutSection = document.getElementById('about');

navButtons.forEach(button => {
    button.addEventListener('click', () => {
        const target = button.getAttribute('data-target');
        homeSection.style.display = 'none';
        contactSection.style.display = 'none';
        humiditySection.style.display = 'none';
        precipitationSection.style.display = 'none';
        favoritesSection.style.display = 'none';
        aboutSection.style.display = 'none';
        if (target === 'home') {
            homeSection.style.display = 'flex';
        } else if (target === 'contact') {
            contactSection.style.display = 'flex';
        } else if (target === 'humidity') {
            humiditySection.style.display = 'flex';
        } else if (target === 'precipitation') {
            precipitationSection.style.display = 'flex';
        } else if (target === 'favorites') {
            favoritesSection.style.display = 'flex';
        } else if (target === 'about') {
            aboutSection.style.display = 'flex';
        }
    });
});

let favorites = JSON.parse(localStorage.getItem('favorites')) || [];

searchBar.addEventListener('keypress', (event) => {
    if (event.key === 'Enter') {
        const city = searchBar.value;
        getWeatherData(city);
        getHourlyForecast(city);
    }
});

addFavoriteButton.addEventListener('click', () => {
    const city = cityName.textContent;
    if (favorites.includes(city)) {
        favorites = favorites.filter(fav => fav !== city);
        addFavoriteButton.textContent = 'Add to Favorites';
    } else {
        if (city && favorites.length < 10) { // Limit to 10 favorites
            favorites.push(city);
            addFavoriteButton.textContent = 'Remove from Favorites';
        }
    }
    localStorage.setItem('favorites', JSON.stringify(favorites));
    renderFavorites();
});

sendButton.addEventListener('click', () => {
    const message = messageBox.value;
    if (message.trim() !== '') {
        messageBox.value = '';
        notification.style.display = 'block';
        notification.style.opacity = '1';
        setTimeout(() => {
            notification.style.opacity = '0';
            setTimeout(() => {
                notification.style.display = 'none';
            }, 1000);
        }, 2000);
    }
});

function renderFavorites() {
    favoritesList.innerHTML = '';
    favorites.forEach(city => {
        const li = document.createElement('li');
        li.textContent = city;
        const removeButton = document.createElement('button');
        removeButton.textContent = 'Remove';
        removeButton.addEventListener('click', () => {
            favorites = favorites.filter(fav => fav !== city);
            localStorage.setItem('favorites', JSON.stringify(favorites));
            renderFavorites();
            if (cityName.textContent === city) {
                addFavoriteButton.textContent = 'Add to Favorites';
            }
        });
        li.appendChild(removeButton);
        li.addEventListener('click', () => {
            getWeatherData(city);
            getHourlyForecast(city);
            homeSection.style.display = 'flex';
            favoritesSection.style.display = 'none';
        });
        favoritesList.appendChild(li);
    });
}

async function getWeatherData(city) {
    const url = `https://api.openweathermap.org/data/2.5/weather?q=${city}&appid=${apiKey}&units=metric`;
    try {
        const response = await fetch(url);
        const data = await response.json();
        updateWeatherDetails(data);
    } catch (error) {
        console.error('Error fetching weather data:', error);
    }
}

async function getHourlyForecast(city) {
    const url = `https://api.openweathermap.org/data/2.5/forecast?q=${city}&appid=${apiKey}&units=metric`;
    try {
        const response = await fetch(url);
        const data = await response.json();
        updateHourlyForecast(data);
    } catch (error) {
        console.error('Error fetching hourly forecast:', error);
    }
}

function updateWeatherDetails(data) {
    cityName.textContent = data.name;
    temperature.textContent = `${Math.round(data.main.temp)}°C`;
    weatherIcon.src = `http://openweathermap.org/img/wn/${data.weather[0].icon}@2x.png`;
    weatherDescription.textContent = data.weather[0].description;
    weatherDetails.style.display = 'block';
    weatherContainer.classList.add('expanded'); // Add the expanded class

    // Update the button text based on whether the city is in favorites
    if (favorites.includes(data.name)) {
        addFavoriteButton.textContent = 'Remove from Favorites';
    } else {
        addFavoriteButton.textContent = 'Add to Favorites';
    }
}

function updateHourlyForecast(data) {
    hourlyForecastContainer.innerHTML = ''; // Clear previous forecast
    const timezoneOffset = data.city.timezone; // Get the timezone offset in seconds
    const forecastList = data.list.slice(0, 9); // Get the first 9 entries (3-hour intervals up to 24 hours)
    forecastList.forEach(forecast => {
        const forecastElement = document.createElement('div');
        forecastElement.classList.add('forecast-item');
        const localTime = new Date((forecast.dt + timezoneOffset) * 1000).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
        const temp = `${Math.round(forecast.main.temp)}°C`;
        const icon = `http://openweathermap.org/img/wn/${forecast.weather[0].icon}.png`;
        const description = forecast.weather[0].description;

        forecastElement.innerHTML = `
            <p>${localTime}</p>
            <img src="${icon}" alt="Weather Icon">
            <p>${temp}</p>
            <p>${description}</p>
        `;
        hourlyForecastContainer.appendChild(forecastElement);
    });
}

// Initial render of favorites
renderFavorites();