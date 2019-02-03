import { Song } from './song';

export interface Playlist {
  id: number;
  name: string;
  vibe: string;
  songs: Song[]
}
