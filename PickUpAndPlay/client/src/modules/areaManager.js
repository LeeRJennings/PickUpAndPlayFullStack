import { getToken } from "./authManager";

const baseUrl = "/api/Area"

export const getAllAreas = () => {
    return getToken().then((token) => {
        return fetch(baseUrl, {
            method: "GET",
            headers: {
                Authorization: `Bearer ${token}`
            }
        }).then((res) => {
           if (res.ok) {
            return res.json()
           } else {
            throw new Error("An unknown error occurred while trying to get areas.")
           }
        })
    })
}