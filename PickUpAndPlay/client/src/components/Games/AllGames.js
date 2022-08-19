import { useEffect, useState } from "react"
import { getAllUpcomingGames, getAllPreviousGames } from "../../modules/gameManager"
import { getLoggedInUser } from "../../modules/authManager"
import { useNavigate } from "react-router-dom"
import { GameCard } from "./GameCard"

export const AllGames = () => {
    const [games, setGames] = useState([])
    const [user, setUser] = useState({})
    const [upcomingOrPrevious, setUpcomingOrPrevious] = useState(false)

    const navigate = useNavigate()

    const getUpcomingGames = () => {
        getAllUpcomingGames()
        .then(games => setGames(games))
    }

    const getPreviousGames = () => {
        getAllPreviousGames()
        .then(games => setGames(games))
    }

    const getUser = () => {
        getLoggedInUser()
        .then(user => setUser(user))
    } 

    useEffect(() => {
        getUpcomingGames()
        getUser()
    }, [])

    const handleClickSeePrevious = () => {
        getPreviousGames()
        setUpcomingOrPrevious(true)
    }

    const handleClickSeeUpcoming = () => {
        getUpcomingGames()
        setUpcomingOrPrevious(false)
    }

    const upcomingAndPreviousButtonRender = () => {
        if (upcomingOrPrevious === false) {
            return (
                <>
                <button type="button" onClick={() => handleClickSeePrevious()}>SEE PREVIOUS GAMES</button>
                </>
            )
        } else if (upcomingOrPrevious === true) {
            return (
                <>
                <button type="button" onClick={() => handleClickSeeUpcoming()}>SEE UPCOMING GAMES</button>
                </>
            )
        }
    }

    return (
        <>
        <button className="addGameButton" type="button" onClick={() => navigate("/games/create")}>ADD GAME</button>
        {upcomingAndPreviousButtonRender()}
        <div className="gameCards">
            {games.map(game => 
                <GameCard key={game.id} game={game} user={user} />)}
        </div>
        </>
    )
}