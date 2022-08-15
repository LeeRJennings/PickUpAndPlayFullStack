import { useEffect, useState } from "react"
import { Card, CardBody, CardTitle, CardSubtitle } from "reactstrap"
import { getLoggedInUser } from "../modules/authManager"

export const Welcome = () => {
    const [user, setUser] = useState({})

    useEffect(() => {
        getLoggedInUser()
        .then(user => setUser(user))
    }, [])
    
    return (
        <div style={{display: "flex", justifyContent: "center"}}>        
            <Card
            style={{
                position: "fixed",
                width: '20rem',
                margin: "0 50%",
                marginTop: "5%",
                textAlign: "center",
                border: "none"
            }}
            >
                <CardBody>
                    <CardTitle tag="h3">
                        Welcome {user.firstName}!
                    </CardTitle>
                </CardBody>
            </Card>
        </div>
    )
}