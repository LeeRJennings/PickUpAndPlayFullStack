export const GameCard = ({ game, user }) => {
    return (
        <>
        <div className="card" id={`gameCard__${game.id}`}>
            <div className="cardContent">
                <h3>{game.title}</h3>
                <p className="gameAddress">
                    <b>{game.parkName}:</b> {game.address}, {game.area.name} 
                </p>
                <div className="gameDetails">
                    <b>Hosted By:</b> {game.userProfile.fullName}
                    <br/>
                    <b>Skill Level:</b> {game.skillLevel.name}
                    <br/>
                    <b>Date:</b> {game.date}
                    <br/>
                    <b>Time:</b> {game.time}
                    <br/>
                    {!game.cleatsRequired && !game.whiteAndDarkShirt && !game.barefootFriendly && !game.dogsAllowed && 
                     !game.playgroundNearby && !game.bathroomsNearby && !game.drinkingWaterNearby && !game.allAges && 
                     !game.eighteenPlus ?  "" 
                     :  <>
                        <b>Additional Info:</b>
                        <ul>
                            {game.cleatsRequired ?
                                <li>cleats required</li> : ""}
                            {game.whiteAndDarkShirt ?
                                <li>white & dark shirt required</li> : ""}
                            {game.barefootFriendly ?
                                <li>barefoot friendly</li> : ""}
                            {game.dogsAllowed ?
                                <li>dogs allowed at park</li> : ""}
                            {game.playgroundNearby ?
                                <li>playground nearby</li> : ""}
                            {game.bathroomsNearby ?
                                <li>bathrooms nearby</li> : ""}
                            {game.drinkingWaterNearby ?
                                <li>drinking water nearby</li> : ""}
                            {game.allAges ?
                                <li>all ages welcome</li> : ""}
                            {game.eighteenPlus ?
                                <li>18+</li> : ""}
                        </ul>
                        </>
                    }
                </div>
            </div>
        </div>
        </>
    )
}