import { getToken } from "./authManager"

const baseUrl = "/api/Game"

export const getAllUpcomingGames = () => {
    return getToken().then((token) => {
        return fetch(`${baseUrl}/Upcoming`, {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`
            }
        }).then((res) => {
            if (res.ok) {
             return res.json()
            } else {
             throw new Error("An unknown error occurred while trying to get upcoming games.")
            }
         })
    })
}

export const getAllPreviousGames = () => {
    return getToken().then((token) => {
        return fetch(`${baseUrl}/Previous`, {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`
            }
        }).then((res) => {
            if (res.ok) {
             return res.json()
            } else {
             throw new Error("An unknown error occurred while trying to get upcoming games.")
            }
         })
    })
}

export const addGame = (game) => {
    return getToken().then((token) => {
        return fetch(baseUrl, {
            method: "POST",
            headers: {
                Authorization: `Bearer ${token}`,
                "Content-Type": "application/json",
            },
            body: JSON.stringify(game),
        }).then((res) => {
            if (res.ok) {
                return res.json()
            } else {
                throw new Error("An unknown error occurred while trying to save your game.")
            }
        })
    })
}