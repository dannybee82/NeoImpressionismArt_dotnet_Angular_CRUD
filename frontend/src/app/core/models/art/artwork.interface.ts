import { Artist } from "../artist/artist.interface";

export interface Artwork {
	id: number,
	name: string,
	description: string,
	artist?: Artist,
	imageId?: number
}
