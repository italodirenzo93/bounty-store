<template>
    <div class="card bounty">
        <div class="card-body">
            <h5 class="card-title">{{bounty.name}}</h5>
            <h6 class="card-subtitle mb-2 text-muted">Alive: <span class="text-success">${{bounty.aliveReward}}</span></h6>
            <h6 class="card-subtitle mb-2 text-muted">Dead: <span class="text-danger">${{bounty.deadReward}}</span></h6>
            <p class="card-text">{{bounty.description}}</p>

            <a v-if="!bounty.captured" href="#" class="card-link" @click.prevent="claimReward">Claim</a>
            <span v-else class="card-link text-muted">Claimed</span>

            <!-- Edit and delete -->
            <router-link :to="{ name: 'edit', params: { id: bounty.id } }" class="card-link">Edit</router-link>
            <a href="#" class="card-link text-danger" @click.prevent="deleteBounty">Delete</a>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
import {apiEndpoint} from '../config';

export default {
    props: {
        bounty: {
            type: Object,
            required: true
        }
    },
    methods: {
        claimReward() {
            axios.put(apiEndpoint + '/' + this.bounty.id, this.bounty).then(() => this.$emit('claimed', this.bounty));
        },
        deleteBounty() {
            axios.delete(apiEndpoint + '/' + this.bounty.id).then(() => this.$emit('deleted', this.bounty.id));
        }
    }
};
</script>
